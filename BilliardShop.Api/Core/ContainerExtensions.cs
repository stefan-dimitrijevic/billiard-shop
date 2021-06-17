using BilliardShop.Application.Commands;
using BilliardShop.Application.Email;
using BilliardShop.Application.Hash;
using BilliardShop.Application.Queries;
using BilliardShop.Implementation.Commands;
using BilliardShop.Implementation.Email;
using BilliardShop.Implementation.Hash;
using BilliardShop.Implementation.Queries;
using BilliardShop.Implementation.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliardShop.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>(); //1
            services.AddTransient<IReadBrandsQuery, EfReadBrandsQuery>(); //2
            services.AddTransient<IReadBrandQuery, EfReadBrandQuery>(); //3
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>(); //4
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>(); //5

            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<UpdateBrandValidator>();

            
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>(); //6
            services.AddTransient<IReadCategoriesQuery, EfReadCategoriesQuery>(); //7
            services.AddTransient<IReadCategoryQuery, EfReadCategoryQuery>(); //8
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>(); //9
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>(); //10

            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();

            
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>(); //11
            services.AddTransient<IReadProductsQuery, EfReadProductsQuery>(); //12
            services.AddTransient<IReadProductQuery, EfReadProductQuery>(); //13
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>(); //14
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>(); //15

            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateProductValidator>();


            
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>(); //16

            services.AddTransient<IReadUsersQuery, EfReadUsersQuery>(); //17
            services.AddTransient<IReadUserQuery, EfReadUserQuery>(); //18
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>(); //19
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>(); //20

            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<UpdateUserValidator>();

            
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            
            services.AddTransient<IHashPassword, HashPassword>();


            
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>(); //21
            services.AddTransient<IReadOrdersQuery, EfReadOrdersQuery>(); //22
            services.AddTransient<IReadOrderQuery, EfReadOrderQuery>(); //23
            services.AddTransient<IUpdateOrderCommand, EfUpdateOrderCommand>(); //24
            services.AddTransient<IDeleteOrderCommand, EfDeleteOrderCommand>(); //25
            services.AddTransient<IChangeOrderStatusCommand, EfChangeOrderStatusCommand>(); //26

            services.AddTransient<CreateOrderValidator>(); 
            services.AddTransient<CreateOrderLineValidator>(); 

            
            services.AddTransient<ICreateUserUseCaseCommand, EfCreateUserUseCaseCommand>(); //27
            services.AddTransient<IReadUserUseCasesQuery, EfReadUserUseCasesQuery>(); //28
            services.AddTransient<IUpdateUserUseCaseCommand, EfUpdateUserUseCaseCommand>(); //29
            services.AddTransient<IDeleteUserUseCaseCommand, EfDeleteUserUseCaseCommand>(); //30

            services.AddTransient<CreateUserUseCaseValidator>();

            
            services.AddTransient<IReadUseCaseLogsQuery, EfReadUseCaseLogsQuery>(); //31
        }
    }

}
