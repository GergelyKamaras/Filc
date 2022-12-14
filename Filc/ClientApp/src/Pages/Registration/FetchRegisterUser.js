
const RegisterUser = (data, role) => {
    const url = "https://localhost:7014/api/governmentadmins/register/" + role;
    fetch(url, {
        method: "POST", headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json',
            "Authorization": "Bearer" + localStorage.getItem("AccessToken")
        },
        body: JSON.stringify(data)
    }).then((response) => response.json())
      .then((result) => {
        if (result.message === "SUCCESS") {
            alert("You have registered the user.");
        } else {
            alert("Something went wrong")
        }
    })

}


export default RegisterUser