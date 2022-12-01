import { useLocation, Navigate, Outlet } from 'react-router-dom';

const RequireAuth = ({allowedRoles}) => {
  const location = useLocation();

  return (
    allowedRoles.includes(localStorage?.userRole)
      ? <Outlet />
      : localStorage?.userEmail
        ? <Navigate to="/Unauthorized" state={{ from: location }} replace />
        : <Navigate to="/" state={{ from: location }} replace />
  );
}

export default RequireAuth;