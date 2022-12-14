import { useLocation, Navigate, Outlet } from 'react-router-dom';
import jwt from 'jwt-decode';

const RequireAuth = ({allowedRoles}) => {
  const location = useLocation();

  return (
    allowedRoles.includes(jwt(localStorage?.AccessToken)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
      ? <Outlet />
      : localStorage?.AccessToken
        ? <Navigate to="/Unauthorized" state={{ from: location }} replace />
        : <Navigate to="/login" state={{ from: location }} replace />
  );
}

export default RequireAuth;