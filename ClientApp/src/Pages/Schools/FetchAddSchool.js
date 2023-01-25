import React from 'react'

const AddSchoolFetch = (data) => {
    fetch("https://localhost:7014/api/government/schools", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            "Authorization": "Bearer " + localStorage.getItem("AccessToken")
        },
        body: JSON.stringify(data)
    }).then((response) => response.json())
    .then((result) => {
      if (result.status === "Success") {
          alert("You have added the school to the database.");
      } else {
          alert("Something went wrong")
      }
  })
}

export default AddSchoolFetch;