using FashionShop.ApiIntegration;
using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Sales;
using FashionShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Claims;

namespace FashionShop.WebApp.Controllers
{
    public class CartController : Controller
    {

        private readonly IProductApiClient _productApiClient;
        /*
        private readonly IConfiguration _configuration;
        private readonly IUserApiClient _userApiClient;
        private readonly ICartApiClient _cartApiClient;
        */
        public CartController(IProductApiClient productApiClient/*,
            IUserApiClient userApiClient,
            IConfiguration configuration,
            ICartApiClient cartApiClient*/)
        {
            _productApiClient = productApiClient;
            /*_userApiClient = userApiClient;
            _configuration = configuration;
            _cartApiClient = cartApiClient;*/
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View(GetCheckoutViewModel());
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel request)
        {
            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderDetailVm>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailVm()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            var checkoutRequest = new CheckoutRequest()
            {
                Address = request.CheckoutModel.Address,
                Name = request.CheckoutModel.Name,
                Email = request.CheckoutModel.Email,
                PhoneNumber = request.CheckoutModel.PhoneNumber,
                OrderDetails = orderDetails
            };
            //TODO: Add to API
            TempData["SuccessMsg"] = "Order puschased successful";
            return View(model);
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentCart);
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);

            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            int quantity = 1;
            if (currentCart.Any(x => x.ProductId == id))
            {
                quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;
            }

            var cartItem = new CartItemViewModel()
            {
                ProductId = id,
                Description = product.Description,
                Image = product.ThumbnailImage,
                Name = product.Name,
                Price = product.Price,
                Quantity = quantity
            };

            currentCart.Add(cartItem);

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            foreach (var item in currentCart)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        private CheckoutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);            
            var checkoutVm = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return checkoutVm;
        }
        #region Cart API

        /*
        
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            var currentCart = await _cartApiClient.GetAllByUserId(culture, userId);
            var checkoutVm = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return View(checkoutVm);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel request)
        {
            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderDetailVm>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailVm()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            var checkoutRequest = new CheckoutRequest()
            {
                Address = request.CheckoutModel.Address,
                Name = request.CheckoutModel.Name,
                Email = request.CheckoutModel.Email,
                PhoneNumber = request.CheckoutModel.PhoneNumber,
                OrderDetails = orderDetails
            };
            //TODO: Add to API
            TempData["SuccessMsg"] = "Order puschased successful";
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetListItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            if(userId == null)
            {
                var session = HttpContext.Session.GetString(SystemConstants.CartSession);
                List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
                if (session != null)
                    currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
                return Ok(currentCart);
            }
            else
            {
                var culture = CultureInfo.CurrentCulture.Name;
                List<CartVm> currentCart = new List<CartVm>();
                currentCart = await _cartApiClient.GetAllByUserId(culture, userId);
                return View(currentCart);
            }
        }
        public async Task<IActionResult> AddToCart(int productId, int quatity)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            
            var product = await _productApiClient.GetById(productId, culture);
            int sl;
            var findCart = await _cartApiClient.FindCartByProductIdOfUser(culture, userId, productId);           
            if (findCart == null)
            {
                if (quatity != null || quatity > 0)
                {
                    sl = quatity;
                }
                else
                {
                    sl = 1;
                }
                var request = new CartCreateRequest()
                {
                    DateCreated = DateTime.Now,
                    LanguageId = culture,
                    Quantity = sl,
                    UserId = userId,
                    Price = product.Price,
                    ProductId = productId,
                };
                var result = await _cartApiClient.CreateCart(request);
                if (result)
                {
                    ViewBag.SuccessMsg = "Đã thêm vào giỏ hàng";
                    return RedirectToAction("Index","Home");
                }
                else{
                    ViewBag.SuccessMsg = "Thêm vào giỏ hàng thất bại!";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                if (quatity != null || quatity > 0)
                {
                    sl = quatity;
                }
                else
                {
                    sl = 1;
                }
                var updateRequest = new CartUpdateRequest()
                {
                    Id = findCart.Id,
                    Quantity = sl+ findCart.Quantity,
                };
                var result = await _cartApiClient.UpdateCart(updateRequest);
                if (result)
                {
                    ViewBag.SuccessMsg = "Đã thêm vào giỏ hàng";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.SuccessMsg = "Thêm vào giỏ hàng thất bại!";
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public async Task<IActionResult> UpdateCart(int id, int quantity)
        {
            int sl;
            var culture = CultureInfo.CurrentCulture.Name;
            var cart = await _cartApiClient.GetById(culture, id);
            if (quantity != null || quantity > 0)
            {
                sl = quantity;
            }
            else
            {
                sl = 1;
            }
            var updateRequest = new CartUpdateRequest()
            {
                Id = id,
                Quantity = sl + cart.Quantity,
            };
            var result = await _cartApiClient.UpdateCart(updateRequest);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return Ok();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("Token");
            if (sessions == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
            base.OnActionExecuting(context);
        }
        */
        #endregion
    }
}