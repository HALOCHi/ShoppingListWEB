$(document).ready(function () {
    $('#registerForm').submit(function (event) {
        event.preventDefault(); // Предотвращаем стандартную отправку формы

        $.ajax({
            type: "POST",
            url: "/Account/Register",
            data: $(this).serialize(), // Сериализуем данные формы
            dataType: "json",
            success: function (response) {
                if (response.success) {
                    // Успех! Перенаправляем на страницу входа
                    window.location.href = response.redirectUrl;
                } else {
                    // Обработка ошибок
                    let errorMessage = "";
                    if (response.error) {
                        // Одно сообщение об ошибке
                        errorMessage = response.error;
                    } else if (response.errors && response.errors.length > 0) {
                        // Несколько ошибок, создаём отформатированный список
                        errorMessage = "<ul>";
                        $.each(response.errors, function (index, error) {
                            errorMessage += "<li>" + error + "</li>";
                        });
                        errorMessage += "</ul>";
                    } else {
                        // Общее сообщение об ошибке
                        errorMessage = "Произошла неизвестная ошибка.";
                    }

                    // Отображаем сообщения об ошибках (предполагается, что у вас есть элемент с id 'registerError')
                    $("#registerError").html(errorMessage).show();
                    //Необязательно: прокручиваем страницу к разделу с ошибками
                    $('html, body').animate({
                        scrollTop: $("#registerError").offset().top
                    }, 500);
                }
            },
            error: function (xhr, status, error) {
                // Обработка ошибок AJAX
                let errorMessage = "Произошла ошибка при отправке запроса.";
                if (xhr.status === 400) {
                    errorMessage = "Некорректные данные формы."; // Добавьте более специфическую обработку ошибок, если они есть на стороне сервера
                }
                $("#registerError").html(errorMessage).show();
                //Необязательно: прокручиваем страницу к разделу с ошибками
                $('html, body').animate({
                    scrollTop: $("#registerError").offset().top
                }, 500);
            }
        });
    });
});