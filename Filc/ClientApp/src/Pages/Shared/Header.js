

import React, {useEffect, useState} from 'react'
import "../../Style/navbar.css"
import jwt from 'jwt-decode'
import NavbarHead from '../Navbar/navbarHead';


function Header(props) {
  const [role , updateRole] = useState(null)
  
    
  useEffect(() => {
    
    try{
      updateRole(jwt(localStorage?.AccessToken)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
      
    }catch{
     
    }
  },[props.loginStatus])
  

  return (
    <div className='navbar'>
      <div className='navbar-title'>
        <a href='/'> For Interactive Learning Community </a>
      </div>
      <div className='navbar-body'>
        <div className='navbar-header'>
          <NavbarHead loginStatus={props.loginStatus} updateLoginStatus={props.updateLoginStatus} loginForm={props.loginForm} role={role}/>
        </div>
      </div>
    </div>
  );
}

{/* {[false].map((expand) => (
        <Navbar role={role} key={expand} bg="light" expand={expand} className="mb-3 navbar own-navbar">
          <Container fluid>
            <Navbar.Brand className='navbar-title' href="">For Interactive Learning Community</Navbar.Brand>
            <Navbar.Toggle aria-controls={`offcanvasNavbar-expand-${expand}`} />
            <Navbar.Offcanvas
              id={`offcanvasNavbar-expand-${expand}`}
              aria-labelledby={`offcanvasNavbarLabel-expand-${expand}`}
              placement="end"
            >
              <Offcanvas.Header closeButton>
                <Offcanvas.Title id={`offcanvasNavbarLabel-expand-${expand}`}>
                    System Management Access
                </Offcanvas.Title>
              </Offcanvas.Header>
              <Offcanvas.Body>
                <Nav.Link href='/'>Home</Nav.Link>
                <Nav className="justify-content-end flex-grow-1 pe-3">
                  {role !== null ?   
                    ( <div>
                      <NavbarLinks role={role} />
                      

                      <NavDropdown
                        title="Profile manager"
                        id={`offcanvasNavbarDropdown-expand-${expand}`}
                        >
                            <NavDropdown.Item href="#action3">Edit personal data</NavDropdown.Item>
                            <NavDropdown.Item href="#action4">Change password</NavDropdown.Item>
                            <NavDropdown.Item href="#action5">Settings</NavDropdown.Item>
                            <NavDropdown.Item onClick={(e) => logout(e)}>Logout</NavDropdown.Item>
                      </NavDropdown>
                    </div>)
                  :
                  
                  (<NavItem>
                    You are not logged in, please login first
                  </NavItem> )}
                  
                </Nav>
                
              </Offcanvas.Body>
            </Navbar.Offcanvas>
          </Container>
        </Navbar>
      ))} */}

export default Header;