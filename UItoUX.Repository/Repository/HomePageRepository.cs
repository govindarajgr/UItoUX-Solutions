using Dapper;
using System.Data;
using UItoUX.DBEngine;
using UItoUX.Framework;
using UItoUX.Models.Output;
using UItoUX.Repository.Interface;

namespace UItoUX.Repository.Repository
{
    public class HomePageRepository(IDapperHandler dapperHandler) : IHomePageRepository
    {
        /// <summary>
        /// Retrieves details for the home page details.
        /// </summary>
        /// <returns>
        /// 1. Brand Details
        /// 2. Product Details
        /// 3. Slide Details
        /// 4. Banner Details
        /// </returns>
        public async Task<HomepageDTO> HomePageDetails()
        {

            HomepageDTO homepageDTO = new();
            var parameters = new DynamicParameters();

            try
            {
                var result = (await dapperHandler.QueryMultipleAsync(StoredProcedure.HomepageDetails, null, CommandType.StoredProcedure));

                if (result != null)
                {
                    homepageDTO.Brands = (await result.ReadAsync<BrandDTO>()).ToList();
                    homepageDTO.Products = (await result.ReadAsync<ProductDTO>()).ToList();
                    homepageDTO.Slides = (await result.ReadAsync<SlideDTO>()).ToList();
                    homepageDTO.Banners = (await result.ReadAsync<BannerDTO>()).ToList();
                }

            }
            catch (Exception)
            {
                //Log the exception
            }

            return homepageDTO;
        }
    }
}
