const SchoolListFetch = async () => {
  const response = await fetch(
    '/api/government/schools', {
          method: 'GET',
          headers: {
              "Authorization": "Bearer " + localStorage.getItem("AccessToken")
          }
    }
  );
  return response.json();
}

export default SchoolListFetch;