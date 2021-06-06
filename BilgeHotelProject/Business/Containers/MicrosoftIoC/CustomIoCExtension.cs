using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {         
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<IRoomDal, EfRoomDal>();

            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IBookingDal, EfBookingDal>();

            services.AddScoped<IRoomTypeService, RoomTypeManager>();
            services.AddScoped<IRoomTypeDal, EfRoomTypeDal>();

            services.AddScoped<IRoomTypeImageService, RoomTypeImageManager>();
            services.AddScoped<IRoomTypeImageDal, EfRoomTypeImageDal>();

            services.AddScoped<IRoomStatusService, RoomStatusManager>();
            services.AddScoped<IRoomStatusDal, EfRoomStatusDal>();

            services.AddScoped<IRoomImageService, RoomImageManager>();
            services.AddScoped<IRoomImageDal, EfRoomImageDal>();

            services.AddScoped<IBookingPackageService, BookingPackageManager>();
            services.AddScoped<IBookingPackageDal, EfBookingPackageDal>();

            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IPaymentDal, EfPaymentDal>();

            services.AddScoped<IPaymentTypeService, PaymentTypeManager>();
            services.AddScoped<IPaymentTypeDal, EfPaymentTypeDal>();

            services.AddScoped<IDutyService, DutyManager>();
            services.AddScoped<IDutyDal, EfDutyDal>();

            services.AddScoped<IGuestService, GuestManager>();
            services.AddScoped<IGuestDal, EfGuestDal>();

            services.AddScoped<IPayrollForManagerService, PayrollForManagerManager>();
            services.AddScoped<IPayrollForManagerDal, EfPayrollForManagerDal>();

            services.AddScoped<IPayrollForWorkerService, PayrollForWorkerManager>();
            services.AddScoped<IPayrollForWorkerDal, EfPayrollForWorkerDal>();

            services.AddScoped<IWorkerService, WorkerManager>();
            services.AddScoped<IWorkerDal, EfWorkerDal>();

            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<IManagerDal, EfManagerDal>();

            services.AddTransient<IValidator<UserForLoginDto>, UserForLoginDtoValidator>();
            services.AddTransient<IValidator<UserForRegisterDto>, UserForRegisterDtoValidator>();
            services.AddTransient<IValidator<BookingPackage>, BookingPackageValidator>();
            services.AddTransient<IValidator<Booking>, BookingValidator>();
            services.AddTransient<IValidator<RoomStatus>, RoomStatusValidator>();
            services.AddTransient<IValidator<RoomType>, RoomTypeValidator>();
            services.AddTransient<IValidator<Room>, RoomValidator>();
            services.AddTransient<IValidator<BookingFilter>, BookingFilterValidator>();
        }
    }
}
