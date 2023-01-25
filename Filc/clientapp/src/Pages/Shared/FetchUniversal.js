import jwt from 'jwt-decode';


/**
 * Universal fetch for data transfer [UNFINISHED]
 * @param {string} type "get" or "post" currently, it will be extended to "update", "put", "delete"
 * @param {string} endpoint The backend endpoint after the role part, accurately. E.g.: if you want to list a school by it's id: "schools/id"
 * @param {any} payload Usually the body of a "post" or "update" or "put" request. For "delete" and "get" leave it blank
 */
async function UniversalFetch(type, endpoint, payload) {
    let response;
    const role = await jwt(localStorage?.AccessToken)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    if (type === "get") {
        response = await fetch(
            `https://localhost:7014/api/${role}/${endpoint}`, {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("AccessToken")
            }
        }
        );
    }

    if (type === "post") {
        response = await fetch(
            `https://localhost:7014/api/${role}/${endpoint}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("AccessToken")
            },
            body: JSON.stringify(payload)
        }
        );
    }

    if (!response.ok) {
        return false;
    }

    return response.json();
 
}

export default UniversalFetch;