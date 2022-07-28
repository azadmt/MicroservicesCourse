//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Primitives;
//using System;
//using System.Linq;
//using System.Transactions;

//namespace Inventory
//{
//    public class EnlistToDistributedTransactionActionFilter : ActionFilterAttribute
//    {
//        private const string TransactionToken = "TransactionToken";


//        /// <summary>  
//        /// Retrieve a transaction propagation token, create a transaction scope and promote   
//        /// the current transaction to a distributed transaction.  
//        /// </summary>  
//        /// <param name="actionContext">The action context.</param>  
//        public override void OnActionExecuting(ActionExecutingContext actionContext)
//        {
         
//            if (actionContext.HttpContext.Request.Headers.ContainsKey(TransactionToken))
//            {
//                actionContext.HttpContext.Request.Headers.TryGetValue(TransactionToken,out StringValues TransactionId);
//                if ( TransactionId.Any())
//                {
//                    byte[] transactionToken = Convert.FromBase64String(TransactionId.FirstOrDefault());
//                    var transaction = TransactionInterop.GetTransactionFromTransmitterPropagationToken(transactionToken);

//                    var transactionScope = new TransactionScope(transaction);

//                    actionContext.HttpContext.Request.Properties.Add(TransactionId, transactionScope);
//                }
//            }
//        }

//        /// <summary>  
//        /// Rollback or commit transaction.  
//        /// </summary>  
//        /// <param name="actionExecutedContext">The action executed context.</param>  
//        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
//        {
//            if (actionExecutedContext.Request.Properties.Keys.Contains(TransactionId))
//            {
//                var transactionScope = actionExecutedContext.Request.Properties[TransactionId] as TransactionScope;

//                if (transactionScope != null)
//                {
//                    if (actionExecutedContext.Exception != null)
//                    {
//                        Transaction.Current.Rollback();
//                    }
//                    else
//                    {
//                        transactionScope.Complete();
//                    }

//                    transactionScope.Dispose();
//                    actionExecutedContext.Request.Properties[TransactionId] = null;
//                }
//            }
//        }
//    }
//}
