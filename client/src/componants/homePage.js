import babushka from '../images/babushka.png';
import '../css/home_page.css';

export default function HomePage() {
    return (
        <div style={{ display: "flex", flexDirection: 'column', justifyContent: "center", alignItems:'center', width: '98vw' }}>
            <div className="paragraph" style={{ width: '60vw' }}>
                <img src={babushka} alt="babushka" style={{ height: '50px', width: '60px' }} />
                <h1 className="paragraph-title" style={{ marginTop: '-3.2vh' }}>הסיפור שלנו</h1>
                <center>
                    בשנת 2010, קבוצה קטנה של בנות עם לב גדול הבינה שאפשר לשנות את חייהם של ילדים עם צרכים מיוחדים על ידי יצירת חיבורים אישיים ומשמעותיים. כך נולדה "נותנים יד" - עמותה שהוקמה מתוך אמונה בכוחם של קשרים אנושיים וביכולת של תמיכה אמיתית לשפר את איכות החיים של ילדים מיוחדים.
                    <br />
                    מתנדבות "נותנים יד" הן הלב הפועם של העמותה. כל אחת מהן מגיעה עם תשוקה ורצון לעשות שינוי. באמצעות פעילות חברתית, לימודית ורגשית, הן מספקות לילדים כלים להתמודד עם האתגרים היומיומיים ולהתפתח באופן אישי. התהליך הזה הוא דו-כיווני: הילדים מקבלים את הביטחון והחיזוקים שהם זקוקים להם, והמתנדבות חוות חוויה מעצימה ומלאה במשמעות.
                    <br />
                    החזון שלנו הוא פשוט אך עוצמתי: להושיט יד ולתמוך בכל דרך אפשרית. אנחנו כאן כדי להעניק לילדים הזדמנויות להתפתח ולצמוח, וכדי להראות שאכפתיות וקשרים אישיים יכולים לשנות עולמות. יחד, אנחנו יוצרים סביבה תומכת וחמה שבה כל ילד יכול לפרוח ולהגיע להישגים מרשימים.
                    <br />
                    הסיפור של "נותנים יד" הוא סיפור של אהבה, מסירות ואמונה בכוחו של האדם. אנחנו ממשיכים להתרחב ולגדול, וכל יום מביא איתו סיפורים חדשים של הצלחה והשראה. יחד, אנחנו בונים עתיד טוב יותר לילדים עם צרכים מיוחדים ומשפיעים על הקהילה כולה.
                </center>
            </div>
            <div className="paragraph" style={{ backgroundColor: 'rgb(255, 238, 217)', width: '98vw' }}>
                <h1 className="paragraph-title">העשיה שלנו במספרים</h1>
                <div style={{ display: 'flex', justifyContent: 'space-between', width: '60%', marginTop: '10vh' }}>
                    <div className="info">
                        <h2 className="info-title">5000+</h2>
                        <div className="info-paragraph"></div>
                    </div>
                    <div className="info">
                        <h2 className="info-title">30</h2>
                        <div className="info-paragraph">ימי פעילות וטיולים נערכו במהלך השנה החולפת בעתויים מיוחדים על מנת להעניק לילדים חוויות משמעותיות ולחזק את הקשרים החברתיים ביניהם.






</div>
                    </div>
                    <div className="info">
                        <h2 className="info-title">7 נופשונים</h2>
                        <div className="info-paragraph"></div>
                    </div>
                </div>
            </div>
        </div>
    )
}