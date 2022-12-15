const FetchSchoolByIdOnStudentRoute = async () => {
    const id = await jwt(localStorage?.AccessToken)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    const response = await fetch(
        `https://localhost:7014/api/students/schools/${id}`, {
        method: 'GET'
    }
    );
    if (!response.ok) {
        return false;
    }
    return response.json();
}

export default FetchSchoolByIdOnStudentRoute;