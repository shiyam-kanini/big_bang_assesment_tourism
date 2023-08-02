using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse.PackageResponses;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip_API.Repositories.PackageRepo
{
    public class RepoCoupon : IRepoCoupon
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new();
        public RepoCoupon(AppDbContext context)
        {
            _context = context;
        }
        List<Coupon> coupons = new();
        Coupon? newCoupon = new();
        CouponResponse couponResponse = new();

        public async Task<CouponResponse> GetAllCoupons()
        {
            try
            {
                coupons = await _context.Coupons.ToListAsync();
                if(coupons.Count <= 0)
                {
                    AddCouponResponse(false, $"{coupons.Count} records found");return couponResponse;
                }
                AddCouponResponse(true, $"{coupons.Count} records found");
                return couponResponse;
            }
            catch(Exception ex)
            {
                AddCouponResponse(false, ex.Message );return couponResponse;
            }
        }

        public async Task<CouponResponse> GetCouponById(string id)
        {
            try
            {
                newCoupon = await _context.Coupons.FindAsync(id);
                if (newCoupon == null)
                {
                    AddCouponResponse(false, $"No coupon found for id : {id}"); return couponResponse;
                }
                coupons.Add(newCoupon);
                AddCouponResponse(true, $"{coupons.Count}({newCoupon.CouponName}) records found");
                return couponResponse;
            }
            catch (Exception ex)
            {
                AddCouponResponse(false, ex.Message); return couponResponse;
            }
        }

        public async Task<CouponResponse> PostCoupon(CouponRequest couponData)
        {
            try
            {
                newCoupon = await _context.Coupons.Where(x => x.CouponName.Equals(couponData.CouponName)).FirstOrDefaultAsync();
                if (newCoupon != null)
                {
                    AddCouponResponse(false, $"{couponData.CouponName} already exists under id : {newCoupon.CouponId}"); return couponResponse;
                }
                AddCoupon($"COUPID{_random.Next(10000,99999)}", couponData, await _context.Packages.FindAsync(couponData.ApplicablePackageId));
                await _context.Coupons.AddAsync(newCoupon);
                await _context.SaveChangesAsync();
                AddCouponResponse(true, $"{newCoupon.CouponId}({couponData.CouponName}) has been added"); return couponResponse;
            }
            catch (Exception ex)
            {
                AddCouponResponse(false, ex.Message); return couponResponse;
            }
        }

        public async Task<CouponResponse> PutCoupon(CouponRequest couponData, string id)
        {
            try
            {
                AddCoupon(id, couponData, await _context.Packages.FindAsync(couponData.ApplicablePackageId));
                _context.Coupons.Update(newCoupon ?? new());
                await _context.SaveChangesAsync();
                AddCouponResponse(true, $"{newCoupon?.CouponId} has been Updated");
                return couponResponse;
            }
            catch (Exception ex)
            {
                AddCouponResponse(false, ex.Message); return couponResponse;
            }
        }

        public async Task<CouponResponse> DeleteCoupon(string id)
        {
            try
            {
                newCoupon = await _context.Coupons.FindAsync(id);
                if (newCoupon == null)
                {
                    AddCouponResponse(false, $"No Coupon found with id : {newCoupon.CouponId}"); return couponResponse;
                }
                await _context.Coupons.Where(x => x.CouponId.Equals(id)).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                AddCouponResponse(true, $"{newCoupon?.CouponId}({newCoupon?.CouponName}) has been deleted");
                return couponResponse;
            }
            catch (Exception ex)
            {
                AddCouponResponse(false, ex.Message); return couponResponse;
            }
        }
        public void AddCoupon(string id, CouponRequest couponData, Package? applicablepackage)
        {
            newCoupon = new()
            {
                CouponId = id,
                CouponName = couponData.CouponName,
                CouponDescription = couponData.CouponDescription,
                CouponDiscountPercentage= couponData.CouponDiscountPercentage,
                CouponExpiration = couponData.CouponExpiration,
                ApplicablePackage = applicablepackage,
            };
        }
        public void AddCouponResponse(bool status, string message)
        {
            couponResponse = new()
            {
                Status = status,
                Message = message,
                Coupons = coupons
            };
        }
    }
}
