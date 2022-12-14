const FetchAllStudents = async () => {
    const response = await fetch(
      'https://localhost:7014/api/governmentadmins/students', {
      method: 'GET'
    }
    );
    return response.json();
  }
  
  export default FetchAllStudents;