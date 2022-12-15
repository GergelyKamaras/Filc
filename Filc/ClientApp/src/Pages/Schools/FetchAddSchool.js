import React from 'react'

const AddSchoolFetch = (data) => {
    fetch("https://localhost:7014/api/governmentadmins/schools", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            "Authorization": "Bearer" + localStorage.getItem("AccessToken")
        },
        body: JSON.stringify(data)
    }).then((response) => response.json()).then((result) => {
        if (result.message === "SUCCESS") {
            alert("You have added the school to the database.");

        } else {
            alert("Something went wrong.")
        }
    })
}

export default AddSchoolFetch;