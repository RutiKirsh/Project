import babushka from '../images/babushka.png'
export default function HomePage() {
    return (
        <body style={{ display: "flex", flexDirection: 'column', justifyContent: "center", width: '98vw', height: '100vh' }}>
            <div class="paragraph" style={{ width: '40vw' }}>
                <img src={babushka} style={{ height: '50px', width: '60px' }}></img>
                <h1>הסיפור שלנו</h1>
                <center>
                    "נותנים יד" היא עמותה שמטרתה ליצור חיבורים משמעותיים בין מתנדבות לבין ילדים עם צרכים מיוחדים. אנחנו מאמינים בכוח של חיבור אישי והענקת תמיכה אמיתית לילדים עם צרכים מיוחדים, כדי לשפר את איכות חייהם ולהעניק להם הזדמנויות להתפתחות אישית. המתנדבות שלנו פועלות בהתמדה ובהתנדבות, מספקות פעילות חברתית, לימודית ורגשית, ומקנות לילדים את הכלים והביטחון להתמודד עם האתגרים היום-יומיים שלהם. אנחנו כאן כדי לתת יד, לסייע ולתמוך בכל דרך אפשרית.
                </center>
            </div>
        </body>
    )
}