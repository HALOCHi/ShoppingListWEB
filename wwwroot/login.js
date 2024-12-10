$(document).ready(function () {
    $('#loginForm').submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            url: "/Account/Login",
            data: $(this).serialize(),
            dataType: "json",
            success: function (response) {
                if (response.success) {
                    window.location.href = response.redirectUrl; // Перенаправляем на list.html
                } else {
                    alert(response.error); // Отображаем сообщение об ошибке
                }
            },
            error: function (xhr, status, error) {
                alert("Ошибка входа: " + error);
            }
        });
    });
});