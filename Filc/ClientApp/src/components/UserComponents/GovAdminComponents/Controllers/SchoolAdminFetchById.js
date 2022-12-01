const SchoolAdminFetchById = async (id) => {
  const response = await fetch(
    `https://localhost:7014/api/governmentadmins/${id}`, {
    method: 'GET'
  }
  );
  if (!response.ok) {
    return JSON.stringify({});
  }
  return response.json();
}

export default SchoolAdminFetchById;