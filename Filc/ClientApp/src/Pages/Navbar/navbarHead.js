import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import "../../Style/navbar.css"
import jwt from "jwt-decode";
import {useNavigate} from 'react-router-dom';
import FetchHashedPassword from "../Login/FetchHashedPassword"
import FetchLogin from "../Login/FetchLogin"
import bcrypt from 'bcryptjs'
import NavbarLinks from './NavbarLinks';
import {useEffect} from "react"

import { useLocation } from 'react-router-dom';

const NavbarHead = (props) => {
  let location = useLocation().pathname

  const navigate = useNavigate();

  async function handleLogin(e)  {
    e.preventDefault();

    const email = props.loginForm["email"]
    const salt = await FetchHashedPassword({"Email": email});

    const data = {
        "Email": email,
        "Password": bcrypt.hashSync(props.loginForm["password"], salt),
        "RememberMe": false
    };
    await FetchLogin(data);
    props.updateLoginStatus(false);

}
  
  const logout = (e) => {
    e.preventDefault();
    localStorage.clear();
    navigate("")
    props.updateLoginStatus(true)
  }

  const getUserToken = () => {
    return jwt(localStorage?.AccessToken);
  }

  const getUserId = () => {
      return getUserToken()["userId"]
  }

  const getUserName = () => {
      return `${getUserToken()["userFirstName"]} ${getUserToken()["userLastName"]}`
  }
  
  useEffect(() => {
    try {
      let token = localStorage?.AccessToken;
      props.loginStatus(false)
      console.log("logged in")
    }catch{
      console.log("nope") 
    }
  },[location])

    return (
      <>
        {props.loginStatus ? (
          <>
            <FontAwesomeIcon icon={faUser} className="navbar-profile-pic-icon"/>
            <div className='navbar-login-section not-login'>
              <p> You are not logged in! </p>
              <button className='navbar-login-button' typeof='button' onClick={(e) => handleLogin(e)}> Login </button>
            </div>
          </>
        ):(
          // logged in
          <>
            <FontAwesomeIcon icon={faUser} className="navbar-profile-pic-icon"/>
            <div className='navbar-login-section login'>
              <h2> Welcome! </h2>
              <p> {getUserName()}</p>
              <button className='navbar-login-button' typeof='button' onClick={(e) => logout(e)}> Logout </button>
            </div>
            <div className="header-body">
              <NavbarLinks role={props.role}/>
            </div>
          </>
        )}
      </>
    )
  }

export default NavbarHead;