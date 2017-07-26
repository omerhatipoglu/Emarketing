var app = angular.module("serviceApp", []);

app.service("dbService", function ($http) {
    this.getAllCategories = function () {
        var categories = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllCategories",
        }).then(function (response) {
            return response.data;
        });
        return categories;
    }
    this.getSubCategoriesByCategoryID = function (ID) {
        var subcategories = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetSubCategoriesByCategoryID/" + ID,
        }).then(function (response) {
            return response.data;
        });
        return subcategories;
    }
    this.getAllCities = function () {
        var cities = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllCities"
        }).then(function (response) {
            return response.data;
        });
        return cities;
    }
    this.register = function (user) {
        var error = $http({
            method: "POST",
            url: "http://localhost:53958/Service/Register",
            params: user
        }).then(function (response) {
            return response.data;
        });
        return error;
    }
    this.login = function (user) {
        var error = $http({
            method: "POST",
            url: "http://localhost:53958/Service/Login",
            params: user
        }).then(function (response) {
            return response.data;
        });
        return error;
    }
    this.logout = function () {
        var x = $http({
            method: "GET",
            url: "http://localhost:53958/Service/Logout",
        }).then(function (response) {
            return response.data;
        });
        return x;
    }
    this.getCategoryByCategoryID = function (ID) {
        var category = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetCategoryByCategoryID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return category;
    }
    this.edit = function (category) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/Edit",
            params: category
        }).then(function (response) {
            return respose.data;
        });
        return Msg;
    }
    this.add = function (categoryadd) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/Add",
            params: categoryadd
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.delete = function (ID) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/Delete/" + ID
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.getAllSubCategories = function () {
        var subcategories = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllSubCategories"
        }).then(function (response) {
            return response.data;
        });
        return subcategories;
    }
    this.getSubCategoryBySubCategoryID = function (ID) {
        var subcategory = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetSubCategoryBySubCategoryID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return subcategory;
    }
    this.subCatEdit = function (subcategory) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SubCatEdit",
            params: subcategory
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.subCatAdd = function (subcategoryadd) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SubCatAdd",
            params: subcategoryadd
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.subCatDelete = function (ID) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SubCatDelete/" + ID,
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.getAllProducts = function () {
        var products = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllProducts"
        }).then(function (response) {
            return response.data;
        });
        return products;
    }
    this.getProductByProductID = function (ID) {
        var product = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetProductByProductID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return product;
    }
    this.proEdit = function (product) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/ProEdit",
            params: product
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.proAdd = function (productadd) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/ProAdd",
            params: productadd
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.proDelete = function (ID) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/ProDelete/" + ID
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.getAllSubProducts = function () {
        var subproducts = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllSubProducts",
        }).then(function (response) {
            return response.data;
        });
        return subproducts;
    }
    this.getSubProductBySubProductID = function (ID) {
        var subproduct = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetSubProductBySubProductID/" + ID,
        }).then(function (response) {
            return response.data;
        });
        return subproduct;
    }
    this.getAllBrands = function () {
        var brands = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllBrands"
        }).then(function (response) {
            return response.data;
        });
        return brands;
    }
    this.subProEdit = function (subproduct) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SubProEdit",
            params: subproduct
        }).then(function (response) {
            return response.data;
        })
        return Msg;
    }
    this.subProAdd = function (subproduct) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SubProAdd",
            params: subproduct
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.subProDelete = function (ID) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SubProDelete/" + ID
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.getBrandByBrandID = function (ID) {
        var brand = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetBrandByBrandID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return brand;
    }
    this.brandEdit = function (brand) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/BrandEdit",
            params: brand
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.brandAdd = function (brandadd) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/BrandAdd",
            params: brandadd
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.brandDelete = function (ID) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/BrandDelete/" + ID
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.getAllUsers = function () {
        var users = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllUsers"
        }).then(function (response) {
            return response.data;
        });
        return users;
    }

    this.getUserByUserID = function (ID) {
        var user = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetUserByUserID/" + ID,
        }).then(function (response) {
            return response.data;
        });
        return user;
    }
    this.userEdit = function (user) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/UserEdit",
            params: user
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.userAdd = function (user) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/UserAdd",
            params: user
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }
    this.userDelete = function (ID) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/UserDelete/" + ID,
        }).then(function (response) {
            return response.data;
        })
        return Msg;
    }
    this.getAllCam = function () {
        var allcam = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllCam"
        }).then(function (response) {
            return response.data;
        });
        return allcam;
    }
    this.getCamByCamID = function (ID) {
        var cam = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetCamByCamID/" + ID
        }).then(function (response) {
            return response.data;
        })
        return cam;
    }
    this.camEdit = function (cam) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/CamEdit",
            params: cam
        }).then(function (response) {
            return response.data;
        })
        return Msg;
    }
    this.catCount = function () {
        var catcount = $http({
            method: "GET",
            url: "http://localhost:53958/Service/CatCount"
        }).then(function (response) {
            return response.data;
        })
        return catcount;
    }
    this.subCatCount = function () {
        var subcatcount = $http({
            method: "GET",
            url: "http://localhost:53958/Service/SubCatCount"
        }).then(function (response) {
            return response.data;
        })
        return subcatcount;
    }
    this.proCount = function () {
        var procount = $http({
            method: "GET",
            url: "http://localhost:53958/Service/ProCount"
        }).then(function (response) {
            return response.data;
        })
        return procount;
    }
    this.subProCount = function () {
        var subprocount = $http({
            method: "GET",
            url: "http://localhost:53958/Service/SubProCount"
        }).then(function (response) {
            return response.data;
        })
        return subprocount;
    }
    this.userCount = function () {
        var usercount = $http({
            method: "GET",
            url: "http://localhost:53958/Service/UserCount"
        }).then(function (response) {
            return response.data;
        })
        return usercount;
    }
    this.getAllOrders = function () {
        var orders = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllOrders"
        }).then(function (response) {
            return response.data;
        })
        return orders;
    }
    this.getAllDetailByOrderID = function (ID) {
        var alldetail = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllDetailByOrderID/" + ID
        }).then(function (response) {
            return response.data;
        })
        return alldetail;
    }
    this.address = function (ID) {
        var sess = $http({
            method: "GET",
            url: "http://localhost:53958/Service/Address/" + ID
        }).then(function (response) {
            return response.data;
        });
        return sess;
    }
    this.getSubProductsBySubCategoryID = function (ID) {
        var subproductsbysubcat = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetSubProductsBySubCategoryID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return subproductsbysubcat;
    }
    this.categoryAddressBySubCategoryID = function (ID) {
        var sess = $http({
            method: "GET",
            url: "http://localhost:53958/Service/CategoryAddressBySubCategoryID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return sess;
    }
    this.getSubProductsByProductID = function (ID) {
        var subproductbypro = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetSubProductsByProductID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return subproductbypro;
    }
    this.productAddressByProductID = function (ID) {
        var sess = $http({
            method: "GET",
            url: "http://localhost:53958/Service/ProductAddressByProductID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return sess;
    }
    this.subProductAddressBySubProductID = function (ID) {
        var sess = $http({
            method: "GET",
            url: "http://localhost:53958/Service/SubProductAddressBySubProductID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return sess;
    }
    this.getSubProductsByCategoryID = function (ID) {
        var subproductsbycat = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetSubProductsByCategoryID/" + ID
        }).then(function (response) {
            return response.data;
        });
        return subproductsbycat;
    }
    this.getAllSezonProducts = function () {
        var sezon = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllSezonProducts",
        }).then(function (response) {
            return response.data;
        });
        return sezon;
    }
    this.getAllRkProducts = function () {
        var reklam = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllRkProducts",

        }).then(function (response) {
            return response.data;
        });
        return reklam;
    }
    this.getAddSepet = function (sepet) {
        var Msg = $http({
            method: "POST",
            url: "http://localhost:53958/Service/GetAddSepet",
            params: sepet
        }).then(function (response) {
            return response.data;
        });
        return Msg;
    }


    this.getAllSepet = function () {
        var cart = $http({
            method: "GET",
            url: "http://localhost:53958/Service/GetAllSepet",

        }).then(function (response) {
            return response.data;
        });
        return cart;
    }

    this.sepetUpdate = function (crt) {
        var up = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SepetUpdate",
            params: crt
        }).then(function (response) {
            return response.data;
        })
        return up;
    }
    this.sepetDelete = function (crt) {
        var del = $http({
            method: "POST",
            url: "http://localhost:53958/Service/SepetDelete",
            params: crt
        }).then(function (response) {
            return response.data;
        })
        return del;
    }
    this.sepetCount = function () {
        var count = $http({
            method: "GET",
            url: "http://localhost:53958/Service/SepetCount"
        }).then(function (response) {
            return response.data;
        })
        return count;
    }
    this.sepetTotal = function () {
        var toplam = $http({
            method: "GET",
            url: "http://localhost:53958/Service/SepetTotal"
        }).then(function (response) {
            return response.data;
        })
        return toplam;
    }
})

app.controller("dbController", function ($scope, dbService) {

    $scope.GetAllCategories = function () {
        dbService.getAllCategories().then(function (result) {
            $scope.categories = result;
        })
    }
    $scope.GetAllCategories();
    $scope.GetSubCategoriesByCategoryID = function (ID) {
        dbService.getSubCategoriesByCategoryID(ID).then(function (result) {
            $scope.Subcategories = result;

        })
    }
    $scope.GetAllCities = function () {
        dbService.getAllCities().then(function (result) {
            $scope.cities = result;
        })
    }
    $scope.Register = function (user) {
        dbService.register(user).then(function (result) {
            $scope.error = result;
            if (result == " ") {
                window.location.href = "/Home/Login";
            }
            else {
                window.location.href = "/Home/Register";
            }
        })
    }
    $scope.Login = function (user) {
        dbService.login(user).then(function (result) {
            if (result == "admin") {
                window.location.href = "/Admin/Admin";
            }
            else if (result == "user"){
                window.location.href = "/Home/Index";
            }
            else {
                $scope.error = result;
            }
        })
    }
    $scope.Logout = function () {
        dbService.logout().then(function (result) {
            $scope.x = result;
            window.location.href = "/Home/Index";
        })
    }
    $scope.GetCategoryByCategoryID = function (ID) {
        dbService.getCategoryByCategoryID(ID).then(function (result) {
            $scope.category = result;
        })
    }
    $scope.Edit = function (category) {
        dbService.edit(category).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllCategories();
        })
    }
    $scope.Add = function (categoryadd) {
        dbService.add(categoryadd).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllCategories();
        })
    }
    $scope.Delete = function (ID) {
        dbService.delete(ID).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllCategories();
        })
    }
    $scope.GetAllSubCategories = function () {
        dbService.getAllSubCategories().then(function (result) {
            $scope.subcategories = result;
        })
    }
    $scope.GetSubCategoryBySubCategoryID = function (ID) {
        dbService.getSubCategoryBySubCategoryID(ID).then(function (result) {
            $scope.subcategory = result;
        })
    }
    $scope.SubCatEdit = function (subcategory) {
        dbService.subCatEdit(subcategory).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllSubCategories();
        })
    }
    $scope.SubCatAdd = function (subcategoryadd) {
        dbService.subCatAdd(subcategoryadd).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllSubCategories();
        })
    }
    $scope.SubCatDelete = function (ID) {
        dbService.subCatDelete(ID).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllSubCategories();
        })
    }
    $scope.GetAllProducts = function () {
        dbService.getAllProducts().then(function (result) {
            $scope.products = result;
        })
    }
    $scope.GetProductByProductID = function (ID) {
        dbService.getProductByProductID(ID).then(function (result) {
            $scope.product = result;
        })
    }
    $scope.ProEdit = function (product) {
        dbService.proEdit(product).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllProducts();
        })
    }
    $scope.ProAdd = function (productadd) {
        dbService.proAdd(productadd).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllProducts();
        })
    }
    $scope.ProDelete = function (ID) {
        dbService.proDelete(ID).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllProducts();
        })
    }
    $scope.GetAllSubProducts = function () {
        dbService.getAllSubProducts().then(function (result) {
            $scope.subproducts = result;
        })
    }
    $scope.GetSubProductBySubProductID = function (ID) {
        dbService.getSubProductBySubProductID(ID).then(function (result) {
            $scope.subproduct = result;
        })
    }
    $scope.SubProEdit = function (subproduct) {
        dbService.subProEdit(subproduct).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllSubProducts();
        })
    }
    $scope.SubProAdd = function (subproduct) {
        dbService.subProAdd(subproduct).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllSubProducts();
            toastr.info(result);
        })
    }
    $scope.SubProDelete = function (ID) {
        dbService.subProDelete(ID).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllSubProducts();
        })
    }
    $scope.GetAllBrands = function () {
        dbService.getAllBrands().then(function (result) {
            $scope.brands = result;
        })
    }
    $scope.GetBrandByBrandID = function (ID) {
        dbService.getBrandByBrandID(ID).then(function (result) {
            $scope.brand = result;
        })
    }
    $scope.BrandEdit = function (brand) {
        dbService.brandEdit(brand).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllBrands();
        })
    }
    $scope.BrandAdd = function (brandadd) {
        dbService.brandAdd(brandadd).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllBrands();
        })
    }
    $scope.BrandDelete = function (ID) {
        dbService.brandDelete(ID).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllBrands();
        })
    }
    $scope.GetAllUsers = function () {
        dbService.getAllUsers().then(function (result) {  // userları getir
            $scope.users = result;
        })
    }
    $scope.GetUserByUserID = function (ID) {
        dbService.getUserByUserID(ID).then(function (result) {
            $scope.user = result;
        })
    }
    $scope.UserEdit = function (user) {
        dbService.userEdit(user).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllUsers();
        })
    }
    $scope.UserAdd = function (user) {
        dbService.userAdd(user).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllUsers();
        })
    }
    $scope.UserDelete = function (ID) {
        dbService.userDelete(ID).then(function (result) {
            $scope.Msg = result;
            $scope.GetAllUsers();
        })
    }
    $scope.GetAllCam = function () {
        dbService.getAllCam().then(function (result) {
            $scope.allcam = result;
        })
    }
    $scope.GetCamByCamID = function (ID) {
        dbService.getCamByCamID(ID).then(function (result) {
            $scope.cam = result;
        })
    }
    $scope.CamEdit = function (cam) {
        dbService.camEdit(cam).then(function (result) {
            $scope.Msg = result;
            scope.GetAllCam();
        })
    }
    $scope.CatCount = function () {
        dbService.catCount().then(function (result) {
            $scope.catcount = result;
        })
    }
    $scope.UserCount = function () {
        dbService.userCount().then(function (result) {
            $scope.usercount = result;
        })
    }
    $scope.SubCatCount = function () {
        dbService.subCatCount().then(function (result) {
            $scope.subcatcount = result;
        })
    }
    $scope.ProCount = function () {
        dbService.proCount().then(function (result) {
            $scope.procount = result;
        })
    }
    $scope.SubProCount = function () {
        dbService.subProCount().then(function (result) {
            $scope.subprocount = result;
        })
    }
    $scope.GetAllOrders = function () {
        dbService.getAllOrders().then(function (result) {
            $scope.orders = result;
        })
    }
    $scope.GetAllDetailByOrderID = function (ID) {
        dbService.getAllDetailByOrderID(ID).then(function (result) {
            $scope.alldetail = result;
            console.log(result);
        })
    }
    $scope.Address = function (ID) {
        dbService.address(ID).then(function (result) {
            $scope.sess = result;
            window.location.href = "/Admin/OrderDetail";
        })
    }
    $scope.GetSubProductsBySubCategoryID = function (ID) {
        dbService.getSubProductsBySubCategoryID(ID).then(function (result) {
            $scope.subproductsbysubcat = result;
        })
    }
    $scope.CategoryAddressBySubCategoryID = function (ID) {
        dbService.categoryAddressBySubCategoryID(ID).then(function (result) {
            $scope.sess = result;
            window.location.href = "/Home/Category";
        })
    }
    $scope.GetSubProductsByProductID = function (ID) {
        dbService.getSubProductsByProductID(ID).then(function (result) {
            $scope.subproductbypro = result;
        })
    }
    $scope.ProductAddressByProductID = function (ID) {
        dbService.productAddressByProductID(ID).then(function (result) {
            $scope.sess = result;
            window.location.href = "/Home/Category2";
        })
    }
    $scope.SubProductAddressBySubProductID = function (ID) {
        dbService.subProductAddressBySubProductID(ID).then(function (result) {
            $scope.sess = result;
            window.location.href = "/Home/Product";
        })
    }
    $scope.GetSubProductsByCategoryID = function (ID) {
        dbService.getSubProductsByCategoryID(ID).then(function (result) {
            $scope.subproductsbycat = result;
        })
    }
    $scope.GetAllSezonProducts = function () {
        dbService.getAllSezonProducts().then(function (result) {
            $scope.sezon = result;
        })
    }
    $scope.GetAllRkProducts = function () {
        dbService.getAllRkProducts().then(function (result) {
            $scope.reklam = result;
        })
    }
    $scope.GetAddSepet = function (sepet) {
        dbService.getAddSepet(sepet).then(function (result) {
            $scope.sepett = result;

            window.location.href = "/Home/Cart";
        })
    }
    $scope.GetAllSepet = function () {
        dbService.getAllSepet().then(function (result) {
            $scope.cart = result;
        })
    }
    $scope.SepetUpdate = function (crt) {
        dbService.sepetUpdate(crt).then(function (result) {
            $scope.GetAllSepet();
            $scope.up = result;

        });
    }
    $scope.SepetDelete = function (crt) {
        dbService.sepetDelete(crt).then(function (result) {
            $scope.GetAllSepet();
            $scope.SepetCount();
            $scope.SepetTotal();
            $scope.del = result;

        });
    }

    $scope.SepetCount = function () {
        dbService.sepetCount().then(function (result) {
            $scope.count = result;

        });
    }

    $scope.SepetTotal = function () {
        dbService.sepetTotal().then(function (result) {
            $scope.toplam = result;

        });
    }
})