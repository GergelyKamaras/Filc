import { Outlet } from 'react-router-dom';
import Header from './Header';
import React from "react";

const Layout = ({loginStatus, updateLoginStatus}) => {
  return (
    <main className="App">
      <Header loginStatus={loginStatus} updateLoginStatus={updateLoginStatus}/>
      <Outlet />
    </main>
  );
}

export default Layout;