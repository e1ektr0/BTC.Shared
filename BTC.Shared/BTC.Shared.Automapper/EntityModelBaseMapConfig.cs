using AutoMapper;

namespace BTC.Shared.Automapper
{
    public abstract class EntityModelBaseMapConfig<TEntity, TModel> : IMapConfig
    {
        /// <summary>
        /// ����� ��� �������� �� �������� ��
        /// </summary>
        protected abstract void MapToModel(IMappingExpression<TEntity, TModel> map);

        /// <summary>
        /// ����� ��� �������� � �������� ��
        /// </summary>
        protected abstract void MapToEntity(IMappingExpression<TModel, TEntity> map);

        /// <summary>
        /// ���������� ����� ��� �������� ��������
        /// </summary>
        public virtual void ConfigMapToSourse(IMapperConfiguration cfg)
        {
            MapToModel(cfg.CreateMap<TEntity, TModel>());
        }

        /// <summary>
        /// ���������� ����� ��� �������� ��������
        /// </summary>
        public virtual void ConfigMapToDestination(IMapperConfiguration cfg)
        {
            MapToEntity(cfg.CreateMap<TModel, TEntity>());
        }
    }
}