// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Функция показа
function show(state) {
	document.getElementById('window').style.display = state;
	document.getElementById('gray').style.display = state;
}	

document.addEventListener("DOMContentLoaded", function (event) {
	$('#sendLogin').on("click", login);

	/*$('header').hide();*/

	//#region переключатель

	onRegister();

	$(window).keyup(function (e) {
		var target = $('.checkbox-green input:focus');
		if (e.keyCode == 9 && $(target).length) {
			$(target).parent().addClass('focused');
		}
	});

	$('.checkbox-green input').focusout(function () {
		$(this).parent().removeClass('focused');
	});

	$('#loginOrRegister').on('change', onRegister)

	//#endregion
});
onRegister = function () {
	var value = $('#loginOrRegister').is(":checked");
	$("#sendLogin").off("click");
	if (value) {
		$('.registerForm').show();
		$('#sendLogin').text('Зарегистрироваться');
		$('#sendLogin').on("click", register);
	}
	else {
		$('.registerForm').hide();
		$('#sendLogin').text('Войти');
		$('#sendLogin').on("click", login);
	}

}
login = function () {
	var dataFrom = getObjectFromForm('.form');
	
	$.ajax({
		url: '/Auth/login',
		method: 'post',
		async: false,
		data: dataFrom,
		error: function (xhr, status, error) {
			alert(xhr.status);
			alert(error);
		}
	});
	
}
register = function () {
	var dataFrom = getObjectFromForm($('.form'));
	$.ajax({
		//
		// Название контроллера/Название метода
		// До этого не работало, поскольку не находил IndexController
		//
		url: '/Auth/CreateClient',
		async: true,
		method: 'post',
		data: dataFrom,
		success: function (data) {
			alert("Успех");
		}
	});
}
getObjectFromForm = function (form) {
	//
	// Используй полную структуру модели, объект которой возвращаешь 
	//
	var obj = {
		Idclients: 0,
		NameClient: $("#NameClient").val(),
		SurnameClient: $("#SurnameClient").val(),
		PatronomycClient: $("#PatronomycClient").val(),
		PhoneClient: $("#tel").val(),
		LoginClient: $("#LoginClient").val(),
		PasswordClient: $("#PasswordClient").val(),

	};

	//$(form).find('input[name],select[name],textarea[name]').each((i, e) => {
	//	var name = $(e).attr('name');
	//	obj[name] = $(e).val();
	//})



	return obj;

}

addToBasket = function (id) {
	$.ajax({
		url: '/Basket/Add',
		async: true,
		method: 'post',
		data: { article: id },
		success: function (data) {
			alert(id);
		}
	});
}
deleteFromBasket = function (id) {
	$.ajax({
		url: '/Basket/Remove',
		async: true,
		method: 'post',
		data: { article: id },
		success: function (data) {
			location.href = "/Basket/Show";
			alert("Успех");
		}
	});
}