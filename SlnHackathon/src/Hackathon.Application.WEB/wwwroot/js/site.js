$(document).ready(() => {
    login = () => {
        let userForm = document.getElementById('username').value;
        let passwordForm = document.getElementById('password').value;
        $.ajax({
            url: '/Home/Login',
            method: 'POST',
            data: {
                userName: userForm,
                passWord: passwordForm
            },
            success: (resp) => {
                if (resp.status == 'success') {
                    var user = {
                        userName: `${resp.username}`
                    };
                    sessionStorage.setItem('user', JSON.stringify(user));
                    window.location.href = '/Home/Index';
                }
                else {
                    alert('erro de login');
                    setTimeout(() => { window.location.reload(); }, 4000);
                }
            }
        })
    };
});