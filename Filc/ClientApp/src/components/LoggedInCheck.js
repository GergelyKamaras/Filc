const LoggedInCheck = () => {
    if (localStorage.getItem("AccessToken") === null){
        return true;
    }
    else {
        return false;
    }
}

export default LoggedInCheck