

import React, {useEffect, useState} from 'react'
import "../../Style/navbar.css"
import jwt from 'jwt-decode'
import SideBarProfile from '../SideBarComponents/SideBarProfile';


function SideBar(props) {
  const [role , updateRole] = useState(null)
  
    
  useEffect(() => {
    if(localStorage?.AccessToken){
      updateRole(jwt(localStorage?.AccessToken)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
    }
    else{
      props.updateLoginStatus(true)
    }
  },[props.loginStatus])
  

  return (
    <div className='navbar'>
      <div className='navbar-title'>
        {/* message for Hajni: This have to be change randomly */}
        <a href='/'> For Interactive Learning Community </a>
      </div>
      <div className='navbar-body'>
        <div className='navbar-header'>
          <SideBarProfile loginStatus={props.loginStatus} updateLoginStatus={props.updateLoginStatus} loginForm={props.loginForm} role={role}/>
        </div>
      </div>
    </div>
  );
}


export default SideBar;