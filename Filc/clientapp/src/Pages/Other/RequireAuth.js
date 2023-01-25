import { useLocation, Navigate, Outlet } from 'react-router-dom';
import jwt from 'jwt-decode';

const RequireAuth = ({allowedRoles}) => {
  const location = useLocation();

    return (
        localStorage?.AccessToken
            ? allowedRoles.includes(jwt(localStorage?.AccessToken)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
                ? <Outlet />
                : <Navigate to="/Unauthorized" state={{ from: location }} replace />
            : <Navigate to="/" state={{ from: location }} replace />
  );
}

export default RequireAuth;