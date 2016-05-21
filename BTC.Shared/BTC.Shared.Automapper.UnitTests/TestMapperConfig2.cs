using AutoMapper;

namespace BTC.Shared.Automapper.UnitTests
{
    public class TestMapperConfig2 : EntityModelBaseMapConfig<TestModel2, TestViewModel>
    {
        protected override void MapToModel(IMappingExpression<TestModel2, TestViewModel> map)
        {

        }

        protected override void MapToEntity(IMappingExpression<TestViewModel, TestModel2> map)
        {
        }
    }
}