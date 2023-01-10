import Icon from "./icons"


const PageTitle = (props) => {
    
    return(
        <>
            <p className='page-title'> {props.pageTitle} </p>
            <Icon pageTitle={props.pageTitle} />
        </>
    )
}

export default PageTitle