const GovAdminListFetch = async () => {
  const response = await fetch(
    'https://localhost:7014/governmentadmins/', {
      method: 'GET'
  }
  );
  return response;
}

export default GovAdminListFetch;