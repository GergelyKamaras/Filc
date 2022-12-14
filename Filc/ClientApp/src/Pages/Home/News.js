import "../../Style/IndexPage/InnerGovNews.css"

const News = () => {
    return (
        <div className="news-box">
            <div className="newsarticle 1">
                    <h3>Hungarian school wins international competition for horseback riding</h3>
                    <p>The horses are all very tired.</p>
                    <p>2022.12.01.</p>
            </div>
            <div className="newsarticle 2">
                    <h3>Free lunch program continues nationwide</h3>
                    <p>The kids are all well fed.</p>
                    <p>2022.11.30.</p>
            </div>
            <div className="newsarticle 3">
                    <h3>Teacher protests continue</h3>
                    <p>The teachers are all pissed.</p>
                    <p>2022.11.29.</p>
            </div>
            {/* {newsArticles.map((newsArticle, i) => (
                <div className="newsarticle">
                    <h3 key={i}>{newsArticle.title}</h3>
                    <p key={i}>{newsArticle.blurb}</p>
                    <p key={i}>{newsArticle.date}</p>
            </div>
            ))} */}
        </div>
    )
}

export default News