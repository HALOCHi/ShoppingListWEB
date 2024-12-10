document.getElementById('registrationForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const username = document.getElementById('username').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;

    if (password !== confirmPassword) {
        alert('Пароли не совпадают!');
        return;
    }

    const response = await fetch('/api/Account/Register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ Username: Username, Email: Email, Password: Password })
    });

    if (response.ok) {
        const data = await response.json();
        if (data.success) {
            alert(data.message); // Отображаем сообщение об успешной регистрации
            window.location.href = 'your-redirect-url'; // Перенаправляем на другую страницу
        } else {
            let errorMessage = '';
            if (data.errors) {
                errorMessage = data.errors.join('\n');
            } else {
                errorMessage = 'Произошла ошибка при регистрации.';
            }
            alert(errorMessage); // Отображаем сообщение об ошибке
        }
    } else {
        alert('Произошла ошибка при регистрации. Пожалуйста, попробуйте позже.');
    }
});