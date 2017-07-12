using RedisCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Threading.Models;

namespace Threading.Controllers
{
    public class SaleController : AsyncController
    {
        private static Timer _timer;//定时器
        // GET: Sale
        public ActionResult Index()
        {1
            return View();
        }

        [HttpGet]
        public Task<JsonResult> PostOrder(Order order)
        {
            if (order == null || string.IsNullOrEmpty(order.loginname))
            {
                return null;
            }

            //order = new Order();
            //order.loginname = "chengwei";
            //order.username = "程伟";

            return Task.Factory.StartNew(() =>
            {
                //秒杀库存数量
                int Number = 100;
                //返回结果
                OrderResult R = new OrderResult();
                //R.result = true;
                //R.content = "chenggong";

                //缓存数据库拿出请求队列
                List<Order> PostList = RedisUtils.Get<List<Order>>("Sale20170523", 0);
                if (PostList == null)
                {
                    PostList = new List<Order>();
                }
                PostList.Add(order);

                //缓存队列开始
                if (PostList.Count == 1)
                {
                    //创建一个进程,10秒后主动提交数据库
                    _timer = new Timer(new TimerCallback(ProcessorHandler), null, 10000, 0);

                    R.result = true;
                    R.content = "抢购成功";
                }
                //缓存队列达到请求数量
                else if (PostList.Count == Number)
                {
                    _timer.Dispose();
                    ProcessorHandler(null);

                    R.result = true;
                    R.content = "抢购成功";
                }
                //超出库存
                else if (PostList.Count > Number)
                {
                    _timer.Dispose();
                    R.result = false;
                    R.content = "库存不足";
                }
                //正常增加
                else
                {
                    R.result = true;
                    R.content = "抢购成功";
                }

                RedisUtils.Set<List<Order>>("Sale20170523", 0, PostList);
                AsyncManager.Parameters["Result"] = R;
            }).ContinueWith<JsonResult>(t =>
            {
                OrderResult R = AsyncManager.Parameters["Result"] as OrderResult;
                return Json(R, JsonRequestBehavior.AllowGet);
            });

            
        }

        /// <summary>
        /// 批量查数据库方法
        /// </summary>
        /// <param name="obj"></param>
        private void ProcessorHandler(object obj)
        {
            //提交数据库
            List<Order> PostList = RedisUtils.Get<List<Order>>("Sale20170523", 0);



        }





    }
}