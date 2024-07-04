using UItoUX.Framework;
using UItoUX.Models;
using UItoUX.Repository.Interface;
using UItoUX.Service.Interface;

namespace UItoUX.Service.Service
{
    public class HomePageService(IHomePageRepository homePageRepository) : IHomePageService
    {
         /// <summary>
         /// Construct and Retrive the Response
         /// </summary>
         /// <returns></returns>
        public async Task<APIResultArgs> HomePageDetails()
        {
            APIResultArgs aPIResultArgs = new APIResultArgs();

            try
            {
                var result = await homePageRepository.HomePageDetails();

                if(result !=null)
                {
                    aPIResultArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
                    aPIResultArgs.StatusMessage = MessageCatalog.ErrorMessages.Success;
                    aPIResultArgs.ResultData = result;
                }
                else
                {
                    aPIResultArgs.StatusCode = MessageCatalog.ErrorCodes.Failed;
                    aPIResultArgs.StatusMessage = MessageCatalog.ErrorMessages.Failed;
                }

            }
            catch (Exception)
            {
                //Log the exception
            }

            return aPIResultArgs;
        }
    }
}
