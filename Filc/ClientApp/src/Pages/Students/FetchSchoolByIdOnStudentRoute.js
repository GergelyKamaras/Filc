import jwt from 'jwt-decode';

const FetchSchoolByIdOnStudentRoute = async () => {
    const id = await jwt(localStorage.AccessToken)["schoolId"];
    console.log(jwt(localStorage.AccessToken));
    const response = await fetch(
        `https://localhost:7014/api/students/schools/${id}`, {
            method: 'GET',
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("AccessToken")
            }
    }
    );
    if (!response.ok) {
        return false;
    }
    return response.json();
}

export default FetchSchoolByIdOnStudentRoute;