const SchoolFetchById = async (id) => {
  const response = await fetch(
    `/api/government/schools/${id}`, {
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

export default SchoolFetchById;