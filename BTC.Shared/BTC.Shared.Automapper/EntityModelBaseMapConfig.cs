using AutoMapper;

namespace BTC.Shared.Automapper
{
    public abstract class EntityModelBaseMapConfig<TEntity, TModel> : IMapConfig
    {
        /// <summary>
        /// Карта для маппинга из сущности бд
        /// </summary>
        protected abstract void MapToModel(IMappingExpression<TEntity, TModel> map);

        /// <summary>
        /// Карта для маппинга в сущности бд
        /// </summary>
        protected abstract void MapToEntity(IMappingExpression<TModel, TEntity> map);

        /// <summary>
        /// Генерирует карту для исходной сущности
        /// </summary>
        public virtual void ConfigMapToSourse(IMapperConfiguration cfg)
        {
            MapToModel(cfg.CreateMap<TEntity, TModel>());
        }

        /// <summary>
        /// Генерирует карту для конечной сущности
        /// </summary>
        public virtual void ConfigMapToDestination(IMapperConfiguration cfg)
        {
            MapToEntity(cfg.CreateMap<TModel, TEntity>());
        }
    }
}