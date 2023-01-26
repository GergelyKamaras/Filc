
const RegisterUser = (data, role) => {
    const url = "/api/government/register/" + role;
    fetch(url, {
        method: "POST", headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json',
            "Authorization": "Bearer " + localStorage.getItem("AccessToken")
        },
        body: JSON.stringify(data)
    }).then((response) => response.json())
      .then((result) => {
        if (result.status === "Success") {
            alert("You have registered the user.");
        } else {
            alert("Something went wrong")
        }
    })

}


export default RegisterUser