using UItoUX.Models.Output;

namespace UItoUX.Repository.Interface
{
    public interface IHomePageRepository
    {
        Task<HomepageDTO> HomePageDetails();
    }
}
