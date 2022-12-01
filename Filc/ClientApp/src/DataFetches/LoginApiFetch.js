
const clickLogin = (e) => {
    e.preventDefault();
    fetch ("/account/login",{
        method: "POST",
        body: JSON.stringify({
            email: this.state.idValue,
            password: this.state.pwValue,
        }),
    }).then((response) => response.json()).then((result)=>{
        if(result.message === "SUCCESS"){
            alert("You are logged in");
            this.goToMain();
        }else{
            alert("Plese check your login information")
        }
    })

}