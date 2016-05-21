using AutoMapper;
using BTC.Shared.Automapper;
using Ninject;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Get<AutoMapperSerivce>().RegisterMapperConfigs<PageEditViewModelMapperConfig>();
            new WizzardPage().MapTo(new PageEditViewModel());
            new WizzardPage2().MapTo(new PageEditViewModel());
        }
    }
    public class WizzardPage2
    {
        public int Id { get; set; }
        public string Name2 { get; set; }
    }
 
    public class WizzardPage
    {
        public int Id { get; set; }
        public string Name2 { get; set; }
    }
 
    internal class PageEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class PageEditViewModelMapperConfig : EntityModelBaseMapConfig<WizzardPage, PageEditViewModel>
    {
        protected override void MapToModel(IMappingExpression<WizzardPage, PageEditViewModel> map)
        {
            map.ForMember(n => n.Name, e => e.MapFrom(x => x.Name2));

        }

        protected override void MapToEntity(IMappingExpression<PageEditViewModel, WizzardPage> map)
        {
            map.ForMember(n => n.Name2, e => e.MapFrom(x => x.Name));
        }

    }   internal class PageEditViewModelMapperConfig2 : EntityModelBaseMapConfig<WizzardPage2, PageEditViewModel>
    {
        protected override void MapToModel(IMappingExpression<WizzardPage2, PageEditViewModel> map)
        {
            map.ForMember(n => n.Name, e => e.MapFrom(x => x.Name2));

        }

        protected override void MapToEntity(IMappingExpression<PageEditViewModel, WizzardPage2> map)
        {
            map.ForMember(n => n.Name2, e => e.MapFrom(x => x.Name));
        }

    }

}
