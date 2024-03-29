
const LoginApiFetch = async (data) => {
    await fetch ("/authentication/login",{
        method: "POST", headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then( (response) => response.json()).then( (result)=>{
        if(result.message === "SUCCESS"){
            alert("You are logged in");
            localStorage.setItem("AccessToken", result.token);
        }else{
            console.log(result)
            alert(result.message)
        }
    })
    }
    
export default LoginApiFetch