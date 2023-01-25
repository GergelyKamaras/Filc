const SchoolAdminFetchById = async (id) => {
  const response = await fetch(
    `https://localhost:7014/api/schooladmins/${id}`, {
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

export default SchoolAdminFetchById;