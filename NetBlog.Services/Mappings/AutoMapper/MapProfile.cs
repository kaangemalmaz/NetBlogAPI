using AutoMapper;
using NetBlog.Business.Repositories.CategoryRepository.Commands.CreateCategory;
using NetBlog.Business.Repositories.CategoryRepository.Commands.UpdateCategory;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Entities.Concrete;
using NetBlog.Entities.Dtos.Category;
using NetBlog.Entities.Dtos.Comment;
using NetBlog.Entities.Dtos.Contact;
using NetBlog.Entities.Dtos.OperaionClaim;
using NetBlog.Entities.Dtos.Post;

namespace NetBlog.Business.Mappings.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<AddCategoryDto, Category>().ReverseMap();
            CreateMap<GetCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<CreateCategoryCommandRequest, Category>().ReverseMap();

            CreateMap<AddCommentDto, Comment>().ReverseMap();
            CreateMap<GetCommentDto, Comment>().ReverseMap();
            CreateMap<UpdateCommentDto, Comment>().ReverseMap();

            CreateMap<AddContactDto, Contact>().ReverseMap();
            CreateMap<GetContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();

            CreateMap<AddPostDto, Post>().ReverseMap();
            CreateMap<GetPostDto, Post>().ReverseMap();
            CreateMap<UpdatePostDto, Post>().ReverseMap();

            CreateMap<OperationClaim, AddOperationClaim>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaim>().ReverseMap();
        }
    }
}
