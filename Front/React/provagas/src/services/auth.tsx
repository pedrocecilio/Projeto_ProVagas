export const usuarioLogado = () => {
    var token = localStorage.getItem('provagas-chave-autenticacao');

    if (token !== null) {
        return true;
    }
    else {
        return false;
    }
};

export const parseJWT = () => {
    var token = localStorage.getItem('provagas-chave-autenticacao');

    if (token) {
        var baseUrl64 = token.split('.')[1];

        var base64 = baseUrl64.replace(/-/g, '+').replace(/-/g, '/');

        return JSON.parse(window.atob(base64));
    }
}