import { Outlet } from 'react-router-dom';
import Header from './Header';
import "../../Style/Shared/layout.css"
import PageTitle from './pageTitle';

const Layout = (props) => {

  return (
    <main className="App">
      <div className='NavLine'>
        <Header loginStatus={props.loginStatus} updateLoginStatus={props.updateLoginStatus} loginForm={props.loginForm}/>
      </div>
      <div className='page-header'>
        <PageTitle PageTitle={props.PageTitle}/>
      </div>
      <div className='content'>
        <Outlet/>
      </div>
    </main>
  );
}

export default Layout;