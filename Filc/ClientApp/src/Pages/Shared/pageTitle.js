
import {IoIosHome} from 'react-icons/io';


const PageTitle = (props) => {
    return(
        <>
            <p className='page-title'> {props.PageTitle} </p>
            <IoIosHome className='home-icon'/>
        </>
    )
}

export default PageTitle