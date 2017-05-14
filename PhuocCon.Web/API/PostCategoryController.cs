using PhuocCon.Model.Models;
using PhuocCon.Service;
using PhuocCon.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PhuocCon.Web.Models;
using System.Collections.Generic;
using PhuocCon.Web.Infrastructure.Extensions;
namespace PhuocCon.Web.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService,IPostCategoryService postCategoryService) : base(errorService) 
        {
            this._postCategoryService = postCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpReponse(request, () =>
            {
                var listCategory = _postCategoryService.GetAll();
                var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVM);
                return reponse;
            });
        }
        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpReponse(request,()=>
                {
                    HttpResponseMessage response =null;
                    if(ModelState.IsValid)
                    {
                        request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                    else
                    {
                        PostCategory newPostCategory = new PostCategory();
                        newPostCategory.UpdatePostCategory(postCategoryViewModel);

                       var category = _postCategoryService.Add(newPostCategory);
                        _postCategoryService.Save();
                        response = request.CreateResponse(HttpStatusCode.Created,category);
                        
                    }
                    return response;
                });
        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var PostCategoryID = _postCategoryService.GetById(postCategoryViewModel.ID);
                    PostCategoryID.UpdatePostCategory(postCategoryViewModel);
                    _postCategoryService.Update(PostCategoryID);
                    _postCategoryService.Save(); 
                }
                return response;
            });
        }
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategoryService.Delete(id);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

    }
}