import { useLocation, Navigate, Outlet } from 'react-router-dom';

const RequireAuth = ({allowedRoles}) => {
  const location = useLocation();

  return (
    localStorage?.token?.claims[1]?.find(role => allowedRoles.includes(role))
      ? <Outlet />
      : localStorage?.token
        ? <Navigate to="*" state={{ from: location }} replace />
        : <Navigate to="/" state={{ from: location }} replace />
  );
}