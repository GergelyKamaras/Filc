const SchoolFetchById = async (id) => {
  const response = await fetch(
    `https://localhost:7014/api/governmentadmins/schools/${id}`, {
          method: 'GET',
          headers: {
              "Authorization": "Bearer" + localStorage.getItem("AccessToken")
          }
  }
  );
  if (!response.ok) {
    return false;
  }
  return response.json();
}

export default SchoolFetchById;