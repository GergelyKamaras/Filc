import "../../Style/Other/404page.css"

const Unauthorized = () => {

  return (
    <>
      <div className="center">
        <div className="error">
          <div className="number">4</div>
          <div className="illustration">
            <div className="circle" />
            <div className="clip">
              <div className="paper">
                <div className="face">
                  <div className="eyes">
                    <div className="eye eye-left" />
                    <div className="eye eye-right" />
                  </div>
                  <div className="rosyCheeks rosyCheeks-left" />
                  <div className="rosyCheeks rosyCheeks-right" />
                  <div className="mouth" />
                </div>
              </div>
            </div>
          </div>
          <div className="number">1</div>
        </div>
        <div className="text">Oops. You dont have a perminission!</div>
        <a className="button" href="/">
          Turn back
        </a>
      </div>
    </>
  )
}


export default Unauthorized;