const GovAdminListFetchById = async (id) => {
  const response = await fetch(
    `https://localhost:7014/api/governmentadmins/${id}`, {
    method: 'GET'
  }
  );
  return response;
}

export default GovAdminListFetchById;