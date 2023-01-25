const FetchAllStudents = async () => {
    const response = await fetch(
      'https://localhost:7014/api/government/students', {
            method: 'GET',
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("AccessToken")
            }
    }
    );
    return response.json();
  }
  
  export default FetchAllStudents;